//Modal js
$(function () {
    'use strict'

    // showing modal with effect
    $('.modal-effect').on('click', function (e) {
        e.preventDefault();
        var effect = $(this).attr('data-effect');
        $('.modal').addClass(effect);

    });

    // hide modal with effect
    $('.modal').on('hidden.bs.modal', function (e) {
        $(this).removeClass(function (index, className) {
            return (className.match(/(^|\s)effect-\S+/g) || []).join(' ');
        });
    });

});

//Collapsable Menu
$(function () {
    'use strict'

    if ($('.az-iconbar .nav-link.active').length) {
        var targ = $('.az-iconbar .nav-link.active').attr('href');
        $(targ).addClass('show');

        if (window.matchMedia('(min-width: 1200px)').matches) {
            $('.az-iconbar-aside').addClass('show');
        }

        if (window.matchMedia('(min-width: 992px)').matches &&
            window.matchMedia('(max-width: 1199px)').matches) {
            $('.az-iconbar .nav-link.active').removeClass('active');
        }
    }

    $('.az-iconbar .nav-link').on('click', function (e) {
        e.preventDefault();

        $(this).addClass('active');
        $(this).siblings().removeClass('active');
        $('.az-iconbar .nav-link').removeClass('inactive');

        $('.az-iconbar-aside').addClass('show');
        $('.iconText').removeClass('show');


        var targ = $(this).attr('href');
        $(targ).addClass('show');
        $(targ).siblings().removeClass('show');
    });

    $('.az-iconbar-body .with-sub').on('click', function (e) {
        e.preventDefault();
        $(this).parent().addClass('show');
        $(this).parent().siblings().removeClass('show');
    });

    $('.az-iconbar-toggle-menu').on('click', function (e) {
        e.preventDefault();

        if (window.matchMedia('(min-width: 992px)').matches) {
            $('.az-iconbar .nav-link.active').removeClass('active');
            $('.az-iconbar .nav-link').addClass('inactive');
            $('.az-iconbar-aside').removeClass('show');
            if ($('#asideDashboard .iconText').hasClass('show')) {

            } else {
                $('.iconText').addClass('show');

            }
        } else {
            $('.iconText').toggleClass('remove');
            $('body').removeClass('az-iconbar-show');
        }
    })

    $('#azIconbarShow').on('click', function (e) {
        e.preventDefault();
        $('body').toggleClass('az-iconbar-show');
    });
})

//Sidenav js
$(function () {
    'use strict'

    $('.az-sidebar .with-sub').on('click', function (e) {
        e.preventDefault();
        $(this).parent().toggleClass('show');
        $(this).parent().siblings().removeClass('show');
    })

    $(document).on('click touchstart', function (e) {
        e.stopPropagation();

        // closing of sidebar menu when clicking outside of it
        if (!$(e.target).closest('.az-header-menu-icon').length) {
            var sidebarTarg = $(e.target).closest('.az-sidebar').length;
            if (!sidebarTarg) {
                $('body').removeClass('az-sidebar-show');
            }
        }
    });


    $('#azSidebarToggle').on('click', function (e) {
        e.preventDefault();

        if (window.matchMedia('(min-width: 992px)').matches) {
            $('body').toggleClass('az-sidebar-hide');
        } else {
            $('body').toggleClass('az-sidebar-show');
        }
    });
});

//Validator js
$(function () {
    'use strict'

    $(document).ready(function () {
        $('.select2').select2({
            placeholder: 'Choose one'
        });

        $('.select2-no-search').select2({
            minimumResultsForSearch: Infinity,
            placeholder: 'Choose one'
        });
    });

});

//Forms js
$(function () {
    'use strict'

    // Toggle Switches
    $('.az-toggle').on('click', function () {
        $(this).toggleClass('on');
    })

    /* Color picker
    $('#colorpicker').spectrum({
        color: '#17A2B8'
    });

    $('#showAlpha').spectrum({
        color: 'rgba(23,162,184,0.5)',
        showAlpha: true
    });

    $('#showPaletteOnly').spectrum({
        showPaletteOnly: true,
        showPalette: true,
        color: '#DC3545',
        palette: [
            ['#1D2939', '#fff', '#0866C6', '#23BF08', '#F49917'],
            ['#DC3545', '#17A2B8', '#6610F2', '#fa1e81', '#72e7a6']
        ]
    });*/

    /* Datepicker
    $('.fc-datepicker').datepicker({
        showOtherMonths: true,
        selectOtherMonths: true
    });

    $('#datepickerNoOfMonths').datepicker({
        showOtherMonths: true,
        selectOtherMonths: true,
        numberOfMonths: 2
    });*/

    /* AmazeUI Datetimepicker
    $('#datetimepicker').datetimepicker({
        format: 'yyyy-mm-dd hh:ii',
        autoclose: true
    });

    // jQuery Simple DateTimePicker
    $('#datetimepicker2').appendDtpicker({
        closeOnSelected: true,
        onInit: function (handler) {
            var picker = handler.getPicker();
            $(picker).addClass('az-datetimepicker');
        }
    });

    new Picker(document.querySelector('#datetimepicker3'), {
        headers: true,
        format: 'MMMM DD, YYYY HH:mm',
        text: {
            title: 'Pick a Date and Time',
            year: 'Year',
            month: 'Month',
            day: 'Day',
            hour: 'Hour',
            minute: 'Minute'
        },
    });


    $(document).ready(function () {
        $('.select2').select2({
            placeholder: 'Choose one',
            searchInputPlaceholder: 'Search'
        });

        $('.select2-no-search').select2({
            minimumResultsForSearch: Infinity,
            placeholder: 'Choose one'
        });
    });

    $('.rangeslider1').ionRangeSlider();

    $('.rangeslider2').ionRangeSlider({
        min: 100,
        max: 1000,
        from: 550
    });

    $('.rangeslider3').ionRangeSlider({
        type: 'double',
        grid: true,
        min: 0,
        max: 1000,
        from: 200,
        to: 800,
        prefix: '$'
    });

    $('.rangeslider4').ionRangeSlider({
        type: 'double',
        grid: true,
        min: -1000,
        max: 1000,
        from: -500,
        to: 500,
        step: 250
    });*/

});
