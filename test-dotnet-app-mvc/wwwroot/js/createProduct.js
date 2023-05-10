const createProductInit = () => {

    $("#continueBtn").text = "下一步";
     $("#areaLabel").html("地区");
    $("#countryLabel").html("国家");
    $("#typeLabel").html("类别");
    $("#productNameLabel").html("产品名称");
    $("#daysLabel").html("行程天数");
    $("#nightsLabel").html("晚");
    $("#departureLabel").html("出发地");
    $("#leaveGroupLabel").html("离团地");
    $("#imageUrlsLabel").html("产品图片");
    $("#recommendReasonLabel").html("推荐理由");

    $("#shortDescriptionLabel").html("简短描述");
    $("#transportationLabel").html("交通");
    $("#hotelLabel").html("酒店");
    $("#mealsLabel").html("餐饮");
    $("#attractionsLabel").html("包含景点");

    $("#groupDateLabel").html("团期");
    $("#bookByDateLabel").html("预定截止");
    $("#adultPriceLabel").html("成人价");
    $("#childPriceLabel").html("儿童价");
    $("#seniorPriceLabel").html("老人价");

    $("#priceInclusiveLabel").html("价格包含");
    $("#priceExclusiveLabel").html("价格不含");
    $("#refundChangeDescriptionLabel").html("退款改期说明");
    $("#remarkLabel").html("注意事项");

    $(function () {
        $('.datepicker').datepicker({
            format: 'yyyy-mm-dd'
        });
    });
 
}

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
        $("#saveBtn").attr("disabled", false);
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
        $("#saveBtn").attr("disabled", true);
    }
}