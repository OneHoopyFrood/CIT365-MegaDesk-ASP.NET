(function () {
    // Row click (View details)
    document.querySelectorAll(".quotes tr").forEach((tr) => {
        tr.addEventListener("click", (e) => {
            let id;
            let idCol = e.currentTarget.querySelector("td:first-child input");
            if (idCol && idCol.value) {
                id = idCol.value;
                window.location = "/ViewQuote.cshtml?id=" + id;
            } else {
                console.error("Failed to get ID value")
            }
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