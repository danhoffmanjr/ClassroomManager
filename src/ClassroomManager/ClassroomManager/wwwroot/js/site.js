var form = $("#setup-form").show();

form.steps({
    headerTag: "h3",
    bodyTag: "fieldset",
    onStepChanging: function (event, currentIndex, newIndex) {
        // Allways allow previous action even if the current form is not valid!
        if (currentIndex > newIndex) {
            return true;
        }
        return form.valid();
    },
    onFinishing: function (event, currentIndex) {
        form.validate().settings.ignore = ":disabled";
        return form.valid();
    }
}).validate({
    errorPlacement: function errorPlacement(error, element) { element.before(error); },
    rules: {
        confirm: {
            equalTo: "#password-2"
        },
        password: {
            required: true,
            password: true,
            remote: "/Account/ValidatePassword"
        }
    }
});