//const createProductInit = () => {
//    alert("bruce test");

//    $("#schedule").attr("hidden", true);
//    $("#price-inventory").attr("hidden", true);
//    $("#notices").attr("hidden", true);
//}

const continueBtnClicked = (event) => {
    event.preventDefault();

    if (!$("#basic-info").attr("hidden") === true) {
        $("#basic-info").attr("hidden", true);
        $("#schedule").attr("hidden", false);
        $("#price-inventory").attr("hidden", true);
        $("#notices").attr("hidden", true);
        $("#continueBtn").attr("disabled", false);
        $("#backBtn").attr("disabled", false);
    }
    else if (!$("#schedule").attr("hidden") === true) {
        $("#basic-info").attr("hidden", true);
        $("#schedule").attr("hidden", true);
        $("#price-inventory").attr("hidden", false);
        $("#notices").attr("hidden", true);
        $("#continueBtn").attr("disabled", false);
        $("#backBtn").attr("disabled", false);
    }
    else if (!$("#price-inventory").attr("hidden") === true) {
        $("#basic-info").attr("hidden", true);
        $("#schedule").attr("hidden", true);
        $("#price-inventory").attr("hidden", true);
        $("#notices").attr("hidden", false);
        $("#continueBtn").attr("disabled", true);
        $("#backBtn").attr("disabled", false);
    }

    
}

const backBtnClicked = (event) => {
    event.preventDefault();

    if (!$("#basic-info").attr("hidden") === true) {
        $("#backBtn").attr("disabled", true);
        $("#continiueBtn").attr("disabled", false);
        
    }
    else if (!$("#schedule").attr("hidden") === true) {
        $("#basic-info").attr("hidden", false);
        $("#schedule").attr("hidden", true);
        $("#price-inventory").attr("hidden", true);
        $("#notices").attr("hidden", true);
        $("#backBtn").attr("disabled", false);
        $("#continiueBtn").attr("disabled", false);
    }
    else if (!$("#price-inventory").attr("hidden") === true) {
        $("#basic-info").attr("hidden", true);
        $("#schedule").attr("hidden", false);
        $("#price-inventory").attr("hidden", true);
        $("#notices").attr("hidden", true);
        $("#backBtn").attr("disabled", false);
        $("#continiueBtn").attr("disabled", false);
    }
    else if (!$("#notices").attr("hidden") === true) {
        $("#basic-info").attr("hidden", true);
        $("#schedule").attr("hidden", true);
        $("#price-inventory").attr("hidden", false);
        $("#notices").attr("hidden", true);
        $("#backBtn").attr("disabled", false);
        $("#continueBtn").attr("disabled", false);
    }
}