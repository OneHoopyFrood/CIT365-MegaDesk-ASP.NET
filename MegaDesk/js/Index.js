(function () {
    let tableRows = document.querySelectorAll(".quotes tr");
    tableRows.forEach((tr) => {
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

    let delBtns = document.querySelectorAll(".delete-link");
    delBtns.forEach((btn) => {
        btn.addEventListener("click", confirmDelete, false);
    })

    function confirmDelete(e) {
        if (!window.confirm('Are you sure you want to delete this?')) {
            e.preventDefault();
            e.stopPropagation();
        }
    }
})();