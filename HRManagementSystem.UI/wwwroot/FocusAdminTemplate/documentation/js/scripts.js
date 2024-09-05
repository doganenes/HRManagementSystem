(function ($) {
    "use strict";

    /* 
    ------------------------------------------------
    Sidebar open close animated humberger icon
    ------------------------------------------------*/

    $(".hamburger").on('click', function () {
        $(this).toggleClass("is-active");
    });


    /*  
    -------------------
    List item active
    -------------------*/
    $('.header li, .sidebar li').on('click', function () {
        $(".header li.active, .sidebar li.active").removeClass("active");
        $(this).addClass('active');
    });

    $(".header li").on("click", function (event) {
        event.stopPropagation();
    });

    $(document).on("click", function () {
        $(".header li").removeClass("active");

    });




    /* 
    ---------------
    LobiPanel Function
    ---------------*/
    $(function () {
        $('.lobipanel-basic').lobiPanel({
            sortable: false,
            reload: false,
            editTitle: false,
            unpin: false,
            minimize: {
                icon: 'ti-angle-up',
                icon2: 'ti-angle-down'
            },
            close: {
                icon: 'ti-close'
            },
            expand: {
                icon: 'ti-fullscreen',
                icon2: 'fa fa-compress'
            }
        });
    });


    (function () {
        // Select node, and escape special characters
        var el = document.querySelector('.html'),
            esc = _.escape(el.innerHTML);

        // Reasign escaped to node and initialize highlight.js
        el.innerHTML = esc;
        hljs.highlightBlock(el);
        hljs.initHighlightingOnLoad();


    })();









})(jQuery);