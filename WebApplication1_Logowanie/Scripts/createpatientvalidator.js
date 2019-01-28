$(document).ready(function() {
            $('.submit').click(function(){
              validator();
             });


    function validator() {

        var FirstName = $('#firstnameInput').val();
        var LastName = $('#lastnameInput').val();
        var BornDate = $('#dateInput').val();
        var PatientPhoneNumber = $('#PatientPhoneNumber').val();
        var Email = $('#emailInput').val();

        var inputValue = new Array("FirstName", "LastName", "BornDate", "PatientPhone", "Email");
        var inputMessage = new Array("Imie", "Nazwisko", "Data Urodzenia", "PatientPhoneNumber", "Email");


        if (inputVal[0] === "") {
            $('#imieLabel').after('<span class="error"> Please enter your ' + inputMessage[0] + '</span>');
        }
        else if (!emailReg.test(firstname)) {
            $('#imieLabel').after('<span class="error"> Letters only</span>');
        }


        if (inputVal[1] === "") {
            $('#nazwiskoLabel').after('<span class="error"> Please enter your ' + inputMessage[1] + '</span>');
        }
        else if (!emailReg.test(lastname)) {
            $('#nazwiskoLabel').after('<span class="error"> Letters only</span>');
        }


        if (inputVal[2] === "") {
            $('#borndateLabel').after('<span class="error"> Please enter your ' + inputMessage[2] + '</span>');
        }
        else if (!numberReg.test(borndate)) {
            $('#borndateLabel').after('<span class="error"> Numbers only</span>');
        }


        if (inputVal[3] === "") {
            $('#patienttelephoneLabel').after('<span class="error"> Please enter your ' + inputMessage[3] + '</span>');
        }
        else if (!numberReg.test()) {
            $('#patienttelephoneLabel').after('<span class="error"> Numbers only</span>');
        }


        if (inputVal[4] === "") {
            $('#email').after('<span class="error"> Please enter your ' + inputMessage[3] + '</span>');
        }
        else if (!numberReg.test(email)) {
            $('#email').after('<span class="error"> Please enter a valid email address</span>');
        }

    }
});






