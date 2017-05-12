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

$(".removeproject").click(function () {
    
})

var scrollTop = '';
var newHeight = '100';

$(window).bind('scroll', function () {
    scrollTop = $(window).scrollTop();
    newHeight = scrollTop + 100;
});

$('.removeproject').click(function (e) {
    $("#death").prop("value", $(this).val());
    e.stopPropagation();
    if (jQuery(window).width() < 767) {
        $(this).after($(".popup"));
        $('.popup').show().addClass('popup-mobile').css('top', 0);
        $('html, body').animate({
            scrollTop: $('.popup').offset().top
        }, 500);
    } else {
        $('.popup').removeClass('popup-mobile').css('top', newHeight).toggle();
    };
});

$('html').click(function () {
    $('.popup').hide();
});

$('.popup-btn-close, #cake').click(function (e) {
    $('.popup').hide();
});

$('.popup').click(function (e) {
    e.stopPropagation();
});