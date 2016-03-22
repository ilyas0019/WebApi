
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


    {
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
            },

};*/