(function () {


    var HomePageController = function ($scope, $http, $interval, $filter) {

        var data = [{ ID: "ID", Name: "Not selected", Hobbies: "None" }];

        $scope.countdown = 30;
        $scope.autoSaved;
        $scope.sessionid;

        onServerLoadSuccess = function (response) {
            try {
                $scope.actions.loaddata = new Function(response.data.ToJson);
                alert(response.data.ToJson);
            }
            catch (ex) {
                console.log(ex);
            }
        };

        startCountdown = function () {
            $interval(decrementcountdown, 1000, $scope.countdown);
        };

        decrementcountdown = function () {
            $scope.countdown -= 1;
            if ($scope.countdown < 1) {
                $scope.actions.savepagestate();
                $scope.countdown = 30;
                startCountdown();
            }
        };

        onSuccess = function (resonse) {
            try {
                $scope.vm.gridData = resonse.data.Result;
            }
            catch (ex) {
                console.log(ex);
            }
        };

        onGetVMSuccess = function (resonse) {
            try {
                $scope.vm = JSON.parse(resonse.data.PageVM);
                $scope.vm.app = { message: "Restored page state at :" };
                $scope.autoSaved = Date.now();
            }
            catch (ex) {
                console.log(ex);
            }
        };

        onSaveSuccess = function (resonse) {
            try {

                var result = JSON.parse(resonse.data.PageVM);
                $scope.sessionid = resonse.data._id;
                $scope.vm.app = { message: "Page state saved" };
                $scope.autoSaved = Date.now();
                $scope.sessionid;
                $scope.countdown = 30;
            }
            catch (ex) {
                console.log(ex);
            }
        };

        onError = function (error) {
            alert(error.Result);
        };


        loadfromServer = function () {
            var req = {
                method: 'GET',
                url: 'http://localhost/WebApi.Core/api/appconfig/getapplicationconfig/1',
                headers: { 'Content-Type': 'application/json; charset=utf-8' },
                data: { _id: "loaddata" }
            };
            $http(req).then(onServerLoadSuccess, onError);

        };




        startCountdown();

        //loadfromServer();

        $scope.actions = {

            loaddata: function () {
                try {
                    var req = {
                        method: 'GET',
                        url: 'http://localhost/WebApi.Core/api/employee/getallemployee/1',
                        headers: { 'Content-Type': 'application/json; charset=utf-8' },
                        data: data
                    };
                    $scope.vm.app = { message: "Loaded " };
                    $http(req).then(onSuccess, onError);
                }
                catch (ex) {
                    console.log(ex);
                }
            },

            savepagestate: function () {
                try {
                    var req = {
                        method: 'POST',
                        url: 'http://localhost/WebApi.Core/api/employee/savepagestate/1',
                        headers: { 'Content-Type': 'application/json; charset=utf-8' },
                        data: {
                            UserId: 1,
                            Page: "New",
                            PageVM: JSON.stringify($scope.vm)
                        }
                    };

                    $http(req).then(onSaveSuccess, onError);
                }
                catch (ex) {
                    console.log(ex);
                }
            },

            getpagestate: function () {
                try {
                    var req = {
                        method: 'GET',
                        url: 'http://localhost/WebApi.Core/api/employee/getpagestate/1',
                        headers: { 'Content-Type': 'application/json; charset=utf-8' }
                    };
                    $http(req).then(onGetVMSuccess, onError);

                }
                catch (ex) {
                    console.log(ex);
                }
            }
        };

        $scope.vm = {

            employee: {
                data: {
                    ID: 1,
                    Name: "Default",
                    Department: "Default",
                    Country: "Default",
                    State: "Default",
                    Project: "OMG",
                    JDate: "09/09/2015",
                    IsSelected: false
                },

                countries: [{ name: 'India', code: 'IN' }, { name: 'US', code: 'US' }, { name: 'Afghanistan', code: 'AF' }, { name: 'Åland Islands', code: 'AX' }, { name: 'Albania', code: 'AL' }, { name: 'Algeria', code: 'DZ' }, { name: 'American Samoa', code: 'AS' }, { name: 'AndorrA', code: 'AD' }, { name: 'Angola', code: 'AO' }, { name: 'Anguilla', code: 'AI' }, { name: 'Antarctica', code: 'AQ' }, { name: 'Antigua and Barbuda', code: 'AG' }, { name: 'Argentina', code: 'AR' }, { name: 'Armenia', code: 'AM' }, { name: 'Aruba', code: 'AW' }, { name: 'Australia', code: 'AU' }, { name: 'Austria', code: 'AT' }, { name: 'Azerbaijan', code: 'AZ' }, { name: 'Bahamas', code: 'BS' }, { name: 'Bahrain', code: 'BH' }, { name: 'Bangladesh', code: 'BD' }, { name: 'Barbados', code: 'BB' }, { name: 'Belarus', code: 'BY' }, { name: 'Belgium', code: 'BE' }, { name: 'Belize', code: 'BZ' }, { name: 'Benin', code: 'BJ' }, { name: 'Bermuda', code: 'BM' }, { name: 'Bhutan', code: 'BT' }, { name: 'Bolivia', code: 'BO' }, { name: 'Bosnia and Herzegovina', code: 'BA' }, { name: 'Botswana', code: 'BW' }, { name: 'Bouvet Island', code: 'BV' }, { name: 'Brazil', code: 'BR' }, { name: 'British Indian Ocean Territory', code: 'IO' }, { name: 'Brunei Darussalam', code: 'BN' }, { name: 'Bulgaria', code: 'BG' }, { name: 'Burkina Faso', code: 'BF' }, { name: 'Burundi', code: 'BI' }, { name: 'Cambodia', code: 'KH' }, { name: 'Cameroon', code: 'CM' }, { name: 'Canada', code: 'CA' }, { name: 'Cape Verde', code: 'CV' }, { name: 'Cayman Islands', code: 'KY' }, { name: 'Central African Republic', code: 'CF' }, { name: 'Chad', code: 'TD' }, { name: 'Chile', code: 'CL' }, { name: 'China', code: 'CN' }, { name: 'Christmas Island', code: 'CX' }, { name: 'Cocos (Keeling) Islands', code: 'CC' }, { name: 'Colombia', code: 'CO' }, { name: 'Comoros', code: 'KM' }, { name: 'Congo', code: 'CG' }, { name: 'Congo, The Democratic Republic of the', code: 'CD' }, { name: 'Cook Islands', code: 'CK' }, { name: 'Costa Rica', code: 'CR' }, { name: 'Cote D\'Ivoire', code: 'CI' }, { name: 'Croatia', code: 'HR' }, { name: 'Cuba', code: 'CU' }, { name: 'Cyprus', code: 'CY' }, { name: 'Czech Republic', code: 'CZ' }, { name: 'Denmark', code: 'DK' }, { name: 'Djibouti', code: 'DJ' }, { name: 'Dominica', code: 'DM' }, { name: 'Dominican Republic', code: 'DO' }, { name: 'Ecuador', code: 'EC' }, { name: 'Egypt', code: 'EG' }, { name: 'El Salvador', code: 'SV' }, { name: 'Equatorial Guinea', code: 'GQ' }, { name: 'Eritrea', code: 'ER' }, { name: 'Estonia', code: 'EE' }, { name: 'Ethiopia', code: 'ET' }, { name: 'Falkland Islands (Malvinas)', code: 'FK' }, { name: 'Faroe Islands', code: 'FO' }, { name: 'Fiji', code: 'FJ' }, { name: 'Finland', code: 'FI' }, { name: 'France', code: 'FR' }, { name: 'French Guiana', code: 'GF' }, { name: 'French Polynesia', code: 'PF' }, { name: 'French Southern Territories', code: 'TF' }],

                states: [{ id: "1", "name": "Mumbai" }, { "id": "2", "name": "Delhi" }, { "id": "3", "name": "Bengaluru" }]
            },



            gridData: new kendo.data.ObservableArray([]),

            gridColumns: [
                { field: "ID", title: "ID", filterable: false, type: "inetger" },
                {
                    field: "Name", title: "Name", type: "string",
                    filterable: {
                        cell: {
                            operator: "contains",
                            showOperators: false
                        }
                    }
                },
                { field: "Department", title: "Department", filterable: false, type: "string" },
                { field: "Country", title: "Country", filterable: false, type: "string" },
                { field: "State", title: "State", filterable: false, type: "string" },
                { field: "Project", title: "Project", filterable: false, type: "string" },
                { field: "JDate", title: "JDate", filterable: false, type: "string" },

            ],

            app: { message: "" },

            appName: 'Introducing MongoDB',

            gridSelectedItem: null,

            gridOptions: {
                selectable: "single",
                columns: this.gridColumns,
                scheme: {
                    model: {
                        fields: {
                            ID: { type: "integer" },
                            Name: { type: "string" },
                            Department: { type: "string" },
                            Country: { type: "string" },
                            State: { type: "string" },
                            Project: { type: "string" },
                            JDate: { type: "string" },
                            IsSelected: false

                        }
                    }
                },
                change: function () {

                    var grid = $("#grdKendoGrid").data("kendoGrid");
                    var selectedItem = grid.dataItem(grid.select());
                    $scope.vm.gridSelectedItem = selectedItem;

                    $scope.vm.employee.data.ID = selectedItem.ID;
                    $scope.vm.employee.data.Name = selectedItem.Name;
                    $scope.vm.employee.data.Department = selectedItem.Department;

                    var country = $filter("filter")($scope.vm.employee.countries, { name: selectedItem.Country }, true);
                    $scope.vm.employee.data.Country = country[0];

                    var states = $filter("filter")($scope.vm.employee.states, { name: selectedItem.State }, true);
                    $scope.vm.employee.data.State = states[0];


                    $scope.vm.employee.data.Project = selectedItem.Project;
                    $scope.vm.employee.data.JDate = selectedItem.JDate;

                }

            }

        };
    };


    //-------------------------------------------------------------------//
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
    webui.controller('HomePageController', HomePageController);
}());
