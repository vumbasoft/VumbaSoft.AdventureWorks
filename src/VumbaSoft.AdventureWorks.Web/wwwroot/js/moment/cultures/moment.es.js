(function (global, factory) {
   typeof exports === 'object' && typeof module !== 'undefined'
       && typeof require === 'function' ? factory(require('../moment')) :
   typeof define === 'function' && define.amd ? define(['../moment'], factory) :
   factory(global.moment)
}(this, (function (moment) { 'use strict';
    var es = moment.updateLocale('es', {
        months : 'Enero_Febrero_Marzo_Abril_Mayo_Junio_Julio_Agosto_Septiembre_Octubre_Noviembre_Diciembre'.split('_'),
        monthsShort : 'Ene_Feb_Mar_Abr_May_Jun_Jul_Ago_Sep_Oct_Nov_Dic'.split('_'),
        weekdays : 'Domingo_Lunes_Martes_Miercoles_Jueves_Viernes_Sabado'.split('_'),
        weekdaysShort : 'Dom_Lun_Mar_Mie_Jue_Vie_Sáb'.split('_'),
        weekdaysMin : 'Do_Lu_Ma_Mi_Ju_Vi_Sa'.split('_'),
        longDateFormat : {
            LT : 'HH:mm',
            LTS : 'HH:mm:ss',
            L : 'DD/MM/YYYY',
            LL : 'D MMMM YYYY',
            LLL : 'D MMMM YYYY HH:mm',
            LLLL : 'dddd, D MMMM YYYY HH:mm'
        },
        calendar : {
            sameDay : '[Hoy a las] LT',
            nextDay : '[Mañana a las] LT',
            nextWeek : 'dddd [a] LT',
            lastDay : '[Ayer a las] LT',
            lastWeek : 'dddd [pasada]  [a las] LT',
            sameElse : 'L'
        },
        relativeTime : {
            future : 'en %s',
            past : '% pasados',
            s : 'unos pocos segundos',
            ss : '% segundos',
            m : ' minuto',
            mm : '% minutos',
            h : 'hora',
            hh : '% horas',
            d : 'un día',
            dd : '%unos días',
            M : 'un mes',
            MM : '%unos meses',
            y : 'una añor',
            yy : '%unos años'
        },
        dayOfMonthOrdinalParse: /\d{1,2}(st|nd|rd|th)/,
        ordinal : function (number) {
            var b = number % 10,
                output = (~~(number % 100 / 10) === 1) ? 'th' :
                (b === 1) ? '1º' :
                (b === 2) ? '2º' :
                (b === 3) ? '3º' : 'th';
            return number + output;
        },
        week : {
            dow : 1,
            doy : 4
        }
    });

    if (document.documentElement.lang == 'es') {
        moment.locale('es');
    }

    return es;
})));
