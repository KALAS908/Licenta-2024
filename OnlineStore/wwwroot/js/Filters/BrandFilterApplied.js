﻿function BrandFilterApplied() {
    var selectedBrands = []; 
    function getSelectedBrands() {
        selectedBrands = [];
        $('input[type=checkbox]').each(function () {
            if (this.checked) {
                selectedBrands.push(this.value);
            }
        });
        return selectedBrands;
    }
    function redirectToShoesView(genderId, searchString, page, selectedBrands) {
    
        var url = window.location.pathname;
        url = url + '?&genderId=' + genderId + '&searchString=' + searchString + '&page=' + page + '&selectedBrands=' + selectedBrands;
        window.location.href = url;
    }

    $('#applyFilterButton').click(function () {
        var genderId = $('#genderIdHidden').val();
        var searchString = $('#searchStringHidden').val(); 
        var page = 1;
        selectedBrands = getSelectedBrands();
        selectedBrands = selectedBrands.join(',');
        redirectToShoesView(genderId, searchString, page, selectedBrands);
    });
}






