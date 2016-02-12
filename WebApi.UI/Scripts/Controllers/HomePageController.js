
(function () {
//Controller
    var HomePageController = function ($scope, $http) {
        var objData = {};
        var objFData = {};
        $scope.gridData = [{ ID: "ID", Name: "Not selected", Hobbies: "None" }];

        var tpt = {
            read: function (e) {
                $http(req)
                  .then(function success(response) {
                      e.success(response.data.Result);
                      $scope.gridData = response.data.Result;
                  },
                      function error(response) {
                          alert('something went wrong')
                          console.log(response.data.Result);
                      });
            }
        };

        var dtSource = {
            scheme: { model: { fields: { Name: { type: "string" } } } },
            transport: tpt
        };

        var req = {
            method: 'GET',
            url: 'http://localhost/WebApi.Core/api/employee/getallemployee/1',
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
            data: $scope.filterData
        };

        $scope.labels = {
            lblsearchEmployee: 'Search Employee'
        };

        $scope.model = { searchByName: "Please enter name" };

        $scope.app = { message: "Sample application" };

        $scope.gridOptions = {
            filterable: true,
            pageable: true,
            columns: [
                { field: "ID", title: "ID", filterable: false },
                {
                    field: "Name", title: "Name",
                    filerable: {
                        cell:
                        {
                            multi: true,
                            dataSource: [{ Name: "Iliyas" }, { Name: "Robert" }, { Name: "Sandy" }, { Name: "John" }, { Name: "Lily" }],
                            itemTemplate: function (e) {
                                alert(e);
                                return "<span><label><span>#= data.Name|| data.all #</span><input type='checkbox' name='" + e.field + "' value='#= data.Name#'/></label></span>";
                            }
                        }
                    }
                },
                { field: "Hobbies", title: "Hobbies", filterable: false }
            ],
            dataSource: {
                scheme: {
                    model: {
                        fields: {
                            ID: { type: "integer" },
                            Name: { type: "string" },
                            Hobbies: { type: "string" }
                        }
                    }
                },
                serverPaging: false,
                serverFiltering: false,
                serverSorting: false,
                pageSize: 5,
                transport: tpt
            }
        };
    };
    var webui = angular.module('webui', ['ngRoute', 'kendo.directives']);
    var configFunction = function ($routeProvider) {
        $routeProvider.
            when('/routeOne', {
                templateUrl: '/routesDemo/one'
            })
            .when('/routeTwo', {
                templateUrl: function (params) { return '/routesDemo/two?donuts=' + params.donuts; }
            })
            .when('/routeThree', {
                templateUrl: '/routesDemo/three'
            });
    };
    webui.config(configFunction);
    webui.controller('HomePageController', ['$scope', '$http', HomePageController]);
}());

/*
dropDownEditor = function (element) {
    alert(element);
    element.kendoDropDownList({
        autoBind: false,
        optionLabel: "--Select Value--",
        dataTextField: "Value",
        dataValueField: "Value",
        valuePrimitive: true,
        dataSource: ddDataSource
    });
    alert(element);
};
ddDataSource = function () {
    return new kendo.data.DataSource({
        data: [
        { Value: "Choice One" },
        { Value: "Choice Two" }
        ]
    });
    alert('s');




     //$scope.update = function () {
    //    try {
    //        var req = {
    //            method: 'GET',
    //            url: 'http://localhost/WebApi.Core/api/employee/getallemployee/1',
    //            headers: { 'Content-Type': 'application/json; charset=utf-8' },
    //            data: data
    //        };
    //        $scope.app = { message: "Searching..." };
    //        $http(req).then(onSuccess, onError);
    //    }
    //    catch (ex) {
    //        console.log(ex);
    //    }
    //};


    //onSuccess = function (resonse) {
    //    try {
    //        $scope.gridData = resonse.data.Result;
    //        $scope.app = { message: "Data loaded..." };
    //    }
    //    catch (ex) {
    //        console.log(ex);
    //    }
    //};
    //onError = function (error) {
    //    alert(error.Result);
    //};

    // //$scope.nameEditor = function (container, options) {
    // //    jQuery('<input id="txtName"  required data-text-field="Name" data-value-field="Name" data-bind="value:' + options.field + '"/>')
    // //    .appendTo(container)
    // //    .kendoAutoComplete({
    // //        autoBind: false,
    // //        dataSource: $scope.gridData
    // //    });
    // //};

    // $scope.nameFilter = function (element) {

    //     element.kendoDropDownList({
    //         dataSource: [{ ID: "1", Name: "Iliyas" }, { ID: "2", Name: "John" }],
    //         optionLabel: "--Select Value--"
    //     });
    // };

    // filterTemplate = function (e) {
    //     return "<span><label><span>#= data.ID|| data.all #</span><input type='checkbox' name='ID:" + e.field + "' value='#= data.ID#'/></label></span>";
    // }

};*/