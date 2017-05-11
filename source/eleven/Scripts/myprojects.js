$("#allprojects").click(function () {
    $(".owner").removeClass("hidden");
    $(".shared").removeClass("hidden");
})

$("#myprojects").click(function () {
    $(".owner").removeClass("hidden");
    $(".shared").addClass("hidden");
})

$("#sharedprojects").click(function () {
    $(".owner").addClass("hidden");
    $(".shared").removeClass("hidden");
})