jQuery.noConflict();

(function ($) {
    $(function () {
        if (typeof SCBeacon !== "undefined") {
            SCBeacon.push(['ready', InitSearch]);
        }
        else {
            InitSearch();
        }

        function InitSearch() {
            $('[data-toggle-class]').on('click keypress', function (e) {
                e.preventDefault();
                switch ($(this).data('toggle-class')) {
                    case "is-searching":
                        $('#siteNavbar').collapse('hide');
                        break;
                }
                $($(this).attr('data-target')).toggleClass($(this).attr('data-toggle-class'));
                $(this).parent().find('input').focus();
            });
        }
    });
})(jQuery);
