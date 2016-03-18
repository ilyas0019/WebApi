(function () {

    
    var HomePageController = function ($scope, $http, $interval) {

        var data = [{ ID: "ID", Name: "Not selected", Hobbies: "None" }];
        
        $scope.countdown = 30;
        $scope.autoSaved;

        startCountdown = function () {
            $interval(decrementcountdown, 1000, $scope.countdown);
        };

        decrementcountdown = function () {
            $scope.countdown -= 1;
            if($scope.countdown<1)
            {
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

        onError = function (error) {
            alert(error.Result);
        };

        startCountdown();

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
                            Id: 1,
                            User: 1,
                            Page: "New",
                            PageVM: JSON.stringify($scope.vm)
                        }
                    };
                    
                    $http(req);//.then(onSuccess, onError);
                    $scope.vm.app = { message: "Page state saved" };
                    $scope.autoSaved = Date.now();
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
                    Location: "Default",
                    Department: "Default",
                    Country: "Default",
                    State: "Default",
                    Project: "OMG",
                    JDate: "09/09/2015",
                    IsSelected: false
                },

                location: [{ name: 'Afghanistan', code: 'AF' }, { name: 'Åland Islands', code: 'AX' }, { name: 'Albania', code: 'AL' }, { name: 'Algeria', code: 'DZ' }, { name: 'American Samoa', code: 'AS' }, { name: 'AndorrA', code: 'AD' }, { name: 'Angola', code: 'AO' }, { name: 'Anguilla', code: 'AI' }, { name: 'Antarctica', code: 'AQ' }, { name: 'Antigua and Barbuda', code: 'AG' }, { name: 'Argentina', code: 'AR' }, { name: 'Armenia', code: 'AM' }, { name: 'Aruba', code: 'AW' }, { name: 'Australia', code: 'AU' }, { name: 'Austria', code: 'AT' }, { name: 'Azerbaijan', code: 'AZ' }, { name: 'Bahamas', code: 'BS' }, { name: 'Bahrain', code: 'BH' }, { name: 'Bangladesh', code: 'BD' }, { name: 'Barbados', code: 'BB' }, { name: 'Belarus', code: 'BY' }, { name: 'Belgium', code: 'BE' }, { name: 'Belize', code: 'BZ' }, { name: 'Benin', code: 'BJ' }, { name: 'Bermuda', code: 'BM' }, { name: 'Bhutan', code: 'BT' }, { name: 'Bolivia', code: 'BO' }, { name: 'Bosnia and Herzegovina', code: 'BA' }, { name: 'Botswana', code: 'BW' }, { name: 'Bouvet Island', code: 'BV' }, { name: 'Brazil', code: 'BR' }, { name: 'British Indian Ocean Territory', code: 'IO' }, { name: 'Brunei Darussalam', code: 'BN' }, { name: 'Bulgaria', code: 'BG' }, { name: 'Burkina Faso', code: 'BF' }, { name: 'Burundi', code: 'BI' }, { name: 'Cambodia', code: 'KH' }, { name: 'Cameroon', code: 'CM' }, { name: 'Canada', code: 'CA' }, { name: 'Cape Verde', code: 'CV' }, { name: 'Cayman Islands', code: 'KY' }, { name: 'Central African Republic', code: 'CF' }, { name: 'Chad', code: 'TD' }, { name: 'Chile', code: 'CL' }, { name: 'China', code: 'CN' }, { name: 'Christmas Island', code: 'CX' }, { name: 'Cocos (Keeling) Islands', code: 'CC' }, { name: 'Colombia', code: 'CO' }, { name: 'Comoros', code: 'KM' }, { name: 'Congo', code: 'CG' }, { name: 'Congo, The Democratic Republic of the', code: 'CD' }, { name: 'Cook Islands', code: 'CK' }, { name: 'Costa Rica', code: 'CR' }, { name: 'Cote D\'Ivoire', code: 'CI' }, { name: 'Croatia', code: 'HR' }, { name: 'Cuba', code: 'CU' }, { name: 'Cyprus', code: 'CY' }, { name: 'Czech Republic', code: 'CZ' }, { name: 'Denmark', code: 'DK' }, { name: 'Djibouti', code: 'DJ' }, { name: 'Dominica', code: 'DM' }, { name: 'Dominican Republic', code: 'DO' }, { name: 'Ecuador', code: 'EC' }, { name: 'Egypt', code: 'EG' }, { name: 'El Salvador', code: 'SV' }, { name: 'Equatorial Guinea', code: 'GQ' }, { name: 'Eritrea', code: 'ER' }, { name: 'Estonia', code: 'EE' }, { name: 'Ethiopia', code: 'ET' }, { name: 'Falkland Islands (Malvinas)', code: 'FK' }, { name: 'Faroe Islands', code: 'FO' }, { name: 'Fiji', code: 'FJ' }, { name: 'Finland', code: 'FI' }, { name: 'France', code: 'FR' }, { name: 'French Guiana', code: 'GF' }, { name: 'French Polynesia', code: 'PF' }, { name: 'French Southern Territories', code: 'TF' }],

                states: [{ id: "1", "name": "Mumbai", "state": "Maharashtra" }, { "id": "2", "name": "Delhi", "state": "Delhi" }, { "id": "3", "name": "Bengaluru", "state": "Karnataka" }]
            },



            gridData: new kendo.data.ObservableArray([]),

            gridColumns: [
                { field: "ID", title: "ID", filterable: false, type: "inetger" },
                { field: "Name", title: "Name", type: "string",
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
                { field: "Project", title: "Project", filterable: false, type: "Project" },
                { field: "JDate", title: "JDate", filterable: false, type: "string" },
                
            ],

            labels: { lblsearchEmployee: 'Search Employee' },

            model: { searchByName: "Please enter name" },

            app: { message: "" },

            appName: 'Introducing MongoDB' ,

            gridOptions: {
                columns: this.gridColumns,
                scheme: {
                    model: {
                        fields: {
                            ID: { type: "integer" },
                            Name: { type: "string" },
                            Hobbies: { type: "string" },
                            Location: { type: "string" },
                            Department: { type: "string" },
                            Country: { type: "string" },
                            State: { type: "string" },
                            Project: { type: "string" },
                            JDate: { type: "string" },
                            IsSelected: false

                        }
                    }
                },

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
