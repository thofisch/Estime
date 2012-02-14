
(function (datepicker, timepicker) {
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

	timepicker.regional['da'] = {
		timeFormat: 'hh:mm',
		timeOnlyTitle: 'Klokkeslet',
		timeText: 'Kl.',
		hourText: 'Time',
		minuteText: 'Minut',
		secondText: 'Sekund',
		millisecText: 'Milisekund',
		currentText: 'Nu',
		closeText: 'Luk',
		ampm: false
	};

	datepicker.setDefaults($.datepicker.regional['da']);
	timepicker.setDefaults($.timepicker.regional['da']);

})($.datepicker, $.timepicker);


