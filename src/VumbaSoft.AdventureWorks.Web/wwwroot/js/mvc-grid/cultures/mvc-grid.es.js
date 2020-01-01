if (document.documentElement.lang == 'es')
{
    MvcGrid.prototype.lang = {
        text: {
               'contains': 'Contiene',
                 'equals': 'Igual',
             'not-equals': 'No es igual',
            'starts-with': 'Comienza con',
            'ends-with': 'Termina con'
        },
        number: {
                           'equals': 'Igual',
                       'not-equals': 'No es igual',
                        'less-than': 'Menos que',
                     'greater-than': 'Mas grande que',
               'less-than-or-equal': 'Menor o igual',
            'greater-than-or-equal': 'Mayor que o igual'
        },
        date: {
                           'equals': 'Igual',
                       'not-equals': 'No es igual',
                     'earlier-than': 'Más temprano que',
                       'later-than': 'Más tarde que',
            'earlier-than-or-equal': 'Anterior o igual',
              'later-than-or-equal': 'Más tarde o igual'
        },
        enum: {
                'equals': 'Igual',
            'not-equals': 'No es igual'
        },
        boolean: {
                'equals': 'Igual',
            'not-equals': 'No es igual'
        },
        filter: {
            'apply': '&#10004;',
            'remove': '&#10008;'
        },
        operator: {
            'select': '',
            'and': 'y',
            'or': 'o'
        }
    };
}
