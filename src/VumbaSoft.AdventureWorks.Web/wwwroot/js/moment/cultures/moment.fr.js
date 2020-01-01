(function (global, factory) {
   typeof exports === 'object' && typeof module !== 'undefined'
       && typeof require === 'function' ? factory(require('../moment')) :
   typeof define === 'function' && define.amd ? define(['../moment'], factory) :
   factory(global.moment)
}(this, (function (moment) { 'use strict';
    var fr = moment.updateLocale('fr', {
        months : 'Janvier_Février_Mars_Avril_Mai_Juin_Juillet_Août_Septembre_Octobre_Novembre_Décembre'.split('_'),
        monthsShort : 'Jan_Fév_Mar_Avr_Mai_Jui_Jul_Aoû_Sep_Oct_Nov_Déc'.split('_'),
        weekdays : 'Dimanche_Lundi_Mardi_Mercredi_Jeudi_Vendredi_Samedi'.split('_'),
        weekdaysShort : 'SDim_Lun_Mar_Mer_Jeu_Ven_Sam'.split('_'),
        weekdaysMin : 'Di_Lu_Ma_Me_Je_Ve_Sa'.split('_'),
        longDateFormat : {
            LT : 'HH:mm',
            LTS : 'HH:mm:ss',
            L : 'DD/MM/YYYY',
            LL : 'D MMMM YYYY',
            LLL : 'D MMMM YYYY HH:mm',
            LLLL : 'dddd, D MMMM YYYY HH:mm'
        },
        calendar : {
            sameDay : '[Aujourd`hui à] LT',
            nextDay : '[Demain à] LT',
            nextWeek : 'dddd [at] LT',
            lastDay : '[Hier à] LT',
            lastWeek : 'dddd [Dernier] [à] LT',
            sameElse : 'L'
        },
        relativeTime : {
            future : 'dans %s',
            past : '%s depuis',
            s : 'une seconde',
            ss : '%quelques minutes',
            m : 'une minute',
            mm : '%quelques minute',
            h : 'une heure',
            hh : '%quelques heures',
            d : 'un jour',
            dd : '%quelques jours',
            M : 'un mois',
            MM : '%quelques mois',
            y : 'une année',
            yy : '%quelques années'
        },
        dayOfMonthOrdinalParse: /\d{1,2}(st|nd|rd|th)/,
        ordinal : function (number) {
            var b = number % 10,
                output = (~~(number % 100 / 10) === 1) ? 'th' :
                (b === 1) ? 'st' :
                (b === 2) ? 'nd' :
                (b === 3) ? 'rd' : 'th';
            return number + output;
        },
        week : {
            dow : 1,
            doy : 4
        }
    });

    if (document.documentElement.lang == 'fr') {
        moment.locale('fr');
    }

    return fr;
})));
