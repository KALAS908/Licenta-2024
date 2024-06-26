﻿function BrandCategoryFilterApplied() {
    var selectedBrands = [];
    var selectedMeasures = [];
    function getSelectedBrands() {
        selectedBrands = [];
        $('#brandList input[type=checkbox]').each(function () {
            if (this.checked) {
                selectedBrands.push(this.value);
            }
        });
        return selectedBrands;
    }
    function getSelectedMeasures() {
        selectedMeasures = [];
        $('#measureList input[type=checkbox]').each(function () {
            if (this.checked) {
                selectedMeasures.push(this.value);
            }
        });
        return selectedMeasures;
    }
    function redirectToShoesView(categoryId, searchString, page, selectedBrands, maxPrice , selectedMeasures) {

        var url = window.location.pathname;
        url = url + '?&categoryId=' + categoryId
            + '&searchString=' + searchString
            + '&page=' + page
            + '&selectedBrands=' + selectedBrands
            + '&maxPrice=' + maxPrice
            + '&selectedMeasures=' + selectedMeasures ;
        window.location.href = url;
    }

    $('#applyFilterButton').click(function () {
        var categoryId = $('#categoryIdHidden').val();
        var searchString = $('#searchStringHidden').val();
        var page = 1;
        var maxPrice = document.getElementById("id1").value;
        maxPrice = parseInt(maxPrice);
        selectedBrands = getSelectedBrands();
        selectedBrands = selectedBrands.join(',');
        selectedMeasures = getSelectedMeasures();
        selectedMeasures = selectedMeasures.join(',');
        redirectToShoesView(categoryId, searchString, page, selectedBrands, maxPrice, selectedMeasures);
    });
}