(function (global, factory) {
   typeof exports === 'object' && typeof module !== 'undefined'
       && typeof require === 'function' ? factory(require('../moment')) :
   typeof define === 'function' && define.amd ? define(['../moment'], factory) :
   factory(global.moment)
}(this, (function (moment) { 'use strict';
    var pt = moment.updateLocale('pt', {
        months : 'Janeiro_Fevereiro_Março_Abril_Maio_Junho_Julho_Agosto_Aetembro_Outubro_Novembro_Dezembro'.split('_'),
        monthsShort : 'Jan_Fev_Mar_Abr_Mai_Jun_Jul_Ago_Set_Out_Nov_Dez'.split('_'),
        weekdays : 'Domingo_Segunda_Terça_Quarta_Quinta_Sexta_Sábado'.split('_'),
        weekdaysShort : 'Dom_Seg_Ter_Qua_Qui_Sex_Sáb'.split('_'),
        weekdaysMin : 'Do_Se_Te_Qa_Qt_Se_Sá'.split('_'),
        longDateFormat : {
            LT : 'HH:mm',
            LTS : 'HH:mm:ss',
            L : 'DD/MM/YYYY',
            LL : 'D MMMM YYYY',
            LLL : 'D MMMM YYYY HH:mm',
            LLLL : 'dddd, D MMMM YYYY HH:mm'
        },
        calendar : {
            sameDay : 'Hoje as] LT',
            nextDay : '[Amanha as] LT',
            nextWeek : 'dddd [as] LT',
            lastDay : '[Onten as] LT',
            lastWeek : 'dddd [passada] [as] LT',
            sameElse : 'L'
        },
        relativeTime : {
            future : 'm %s',
            past : '%s depois',
            s : 'um segundo',
            ss : '%alguns segundos',
            m : 'um minuto',
            mm : '%ums minutos',
            h : 'uma hora',
            hh : '%algumas horas',
            d : 'um dia',
            dd : '%alguns días',
            M : 'um mes',
            MM : '%alguns meses',
            y : 'um ano',
            yy : '%alguns anos'
        },
        dayOfMonthOrdinalParse: /\d{1,2}(pr|se|te|th)/,
        ordinal : function (number) {
            var b = number % 10,
                output = (~~(number % 100 / 10) === 1) ? 'th' :
                (b === 1) ? 'pr' :
                (b === 2) ? 'se' :
                (b === 3) ? 'te' : 'th';
            return number + output;
        },
        week : {
            dow : 1,
            doy : 4
        }
    });

    if (document.documentElement.lang == 'pt') {
        moment.locale('pt');
    }

    return pt;
})));
