(function () {
    // Row click (View details)
    document.querySelectorAll(".quotes tr").forEach((tr) => {
        tr.addEventListener("click", (e) => {
            let id;
            let modal = document.getElementById("custom_modal");
            let idCol = e.currentTarget.querySelector("td:first-child input");
            if (idCol && idCol.value) {
                id = idCol.value;
                let url = "/ViewQuote.cshtml?id=" + id;
                fetch(url)
                    .then((res) => {
                        return res.text();
                    })
                    .then((res) => {
                        modal.querySelector(".content").innerHTML = res;
                        modal.style.display = "block";
                    });
            } else {
                console.error("Failed to get ID value")
            }
            modal.querySelector(".close").addEventListener("click", (e) => {
                modal.style.display = "none";
            });
        });
    });

    // Filter by Material
    document.querySelectorAll(".material-filter")[0].addEventListener("change", (e) => {
        let materialValue = e.currentTarget.selectedOptions[0].value;
        let destURL = "?material=" + materialValue;
        if (!materialValue) {
            destURL = window.location.pathname;
        }
        window.location = destURL;
    });

    // Delete confirm
    document.querySelectorAll(".delete-link").forEach((btn) => {
        btn.addEventListener("click", (e) => {
            if (!window.confirm('Are you sure you want to delete this?')) {
                e.preventDefault();
                e.stopPropagation();
            }
        }, false);
    })
})();