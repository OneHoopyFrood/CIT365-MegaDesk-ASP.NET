using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MegaDesk
{
    public class DeskQuote
    {
        public Desk Desk;
        private static Dictionary<int, int[]> rushAdditionalCost = new Dictionary<int, int[]>();
        private string customerName;
        public string CustomerName { get => customerName; set => customerName = value; }
        private decimal? _quoteAmount = null;
        public decimal QuoteAmount
        {
            get
            {
                if (_quoteAmount == null)
                    CalculateQuote();
                return _quoteAmount.Value;
            }
            private set
            {
                _quoteAmount = value;
            }
        }
        public DateTime QuoteDate
        {
            get;
            set;
        }
        public int ProductionDays
        {
            get;
            private set;
        }

        public DeskQuote(string customerName, Desk desk, int productionDays, decimal? quoteAmount = null, DateTime? quoteDate = null)
        {
            if (!rushAdditionalCost.Any())
            {
                var rushOrderPrices = new int[] { 60, 70, 80, 40, 50, 60, 30, 35, 40 };

                rushAdditionalCost.Add(3, new int[] { rushOrderPrices[0], rushOrderPrices[1], rushOrderPrices[2] });
                rushAdditionalCost.Add(5, new int[] { rushOrderPrices[3], rushOrderPrices[4], rushOrderPrices[5] });
                rushAdditionalCost.Add(7, new int[] { rushOrderPrices[6], rushOrderPrices[7], rushOrderPrices[8] });
            }

            this.CustomerName = customerName;
            this.Desk = desk;
            this.ProductionDays = productionDays;

            if (quoteAmount.HasValue)
                QuoteAmount = quoteAmount.Value;
            else
                CalculateQuote();

            QuoteDate = quoteDate.HasValue ? quoteDate.Value : DateTime.Now;
        }

        public DeskQuote(string customerName, int width, int depth, int numDrawers, Desk.DeskMaterial material, int productionDays, decimal? quoteAmount = null, DateTime? quoteDate = null)
            : this(customerName, new Desk(width, depth, numDrawers, material), productionDays, quoteAmount, quoteDate)
        {

        }

        private void CalculateQuote()
        {
            decimal cost = 200;
            int surfaceArea = this.Desk.GetSurfaceArea();
            if (surfaceArea > 1000)
                cost += (surfaceArea - 1000);
            cost += Desk.NumDrawers * 50;

            switch (this.Desk.Material)
            {
                case Desk.DeskMaterial.Pine:
                    cost += 50;
                    break;
                case Desk.DeskMaterial.Laminate:
                    cost += 100;
                    break;
                case Desk.DeskMaterial.Veneer:
                    cost += 125;
                    break;
                case Desk.DeskMaterial.Oak:
                    cost += 200;
                    break;
                case Desk.DeskMaterial.Rosewood:
                    cost += 300;
                    break;
            }

            if (IsRush())
            {
                var sa = Desk.GetSurfaceArea();
                if (sa < 1000)
                {
                    cost += (decimal)rushAdditionalCost[ProductionDays][0];
                }
                else if(sa < 2001)
                {
                    cost += (decimal)rushAdditionalCost[ProductionDays][1];
                }
                else
                {
                    cost += (decimal)rushAdditionalCost[ProductionDays][2];
                }
            }

            this.QuoteAmount = cost;
        }

        private bool IsRush()
        {
            return ProductionDays < 14; 
        }
    }
}
