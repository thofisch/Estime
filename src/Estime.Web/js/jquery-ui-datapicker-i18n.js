

(function (datepicker) {
	'use strict';

	datepicker.regional['da'] = {
		closeText: 'Luk',
		prevText: 'Forrige',
		nextText: 'Næste',
		currentText: 'I dag',
		monthNames: ['Januar', 'Februar', 'Marts', 'April', 'Maj', 'Juni', 'Juli', 'August', 'September', 'Oktober', 'November', 'December'],
		monthNamesShort: ['Jan', 'Feb', 'Mar', 'Apr', 'Maj', 'Jun', 'Jul', 'Aug', 'Sep', 'Okt', 'Nov', 'Dec'],
		dayNames: ['Mandag', 'Tirsdag', 'Onsdag', 'Torsdag', 'Fredag', 'Lørdag', 'Søndag'],
		dayNamesShort: ['Man', 'Tirs', 'Ons', 'Tors', 'Fre', 'Lør', 'Søn'],
		dayNamesMin: ['Ma', 'Ti', 'On', 'To', 'Fr', 'Lø', 'Sø'],
		weekHeader: 'Uge',
		dateFormat: 'yy-mm-dd',
		firstDay: 0,
		isRTL: false,
		showMonthAfterYear: false,
		yearSuffix: ''
	};

	datepicker.setDefaults($.datepicker.regional['da']);
	
})($.datepicker);

