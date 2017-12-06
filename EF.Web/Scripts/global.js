/*global window, $*/
var Global = {};
Global.FormHelper = function (formElement, options, onSucccess, onError) {          
    formElement.submit(function (e) { 
        var submitBtn =  formElement.find(':submit');       
            $.ajax(formElement.attr("action"), {
                type: "POST",
                data: formElement.serializeArray(),
                success: function (result) {
                    alert(result.isSuccess);
                    if (onSucccess === null || onSucccess === undefined) {                      
                        if (result.isSuccess) {
                            window.location.href = result.redirectUrl;
                        } 
                    } else {
                        onSucccess(result);
                    }
                },
                error: function (jqXHR, status, error) {
                    if (onError !== null && onError !== undefined) {
                        onError(jqXHR, status, error);
                    }
                }
            });        
        e.preventDefault();
    });
    return formElement;
};


