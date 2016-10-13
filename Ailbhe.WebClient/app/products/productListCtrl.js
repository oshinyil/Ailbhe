(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("ProductListCtrl",
                     ["productResource",
                         ProductListCtrl]);

    function ProductListCtrl(productResource) {
        var vm = this;

        vm.SearchCriteria = "GDN";

        productResource.query({ search: vm.SearchCriteria }, function (data) {
            vm.products = data;
        });
    }
}());
