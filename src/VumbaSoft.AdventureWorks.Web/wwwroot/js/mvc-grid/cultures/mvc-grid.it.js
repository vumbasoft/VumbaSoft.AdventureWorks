if (document.documentElement.lang == 'it')
{
    MvcGrid.prototype.lang = {
        text: {
               'contains': 'Contiene',
                 'equals': 'È uguale a',
             'not-equals': 'Non uguale',
            'starts-with': 'Inizia con',
              'ends-with': 'Finisce con'
        },
        number: {
                           'equals': 'È uguale a',
                       'not-equals': 'Non uguale',
                        'less-than': 'Meno di',
                     'greater-than': 'Più grande di',
               'less-than-or-equal': 'Minore o uguale',
            'greater-than-or-equal': 'Maggiore o uguale'
        },
        date: {
                           'equals': 'È uguale a',
                       'not-equals': 'Non uguale',
                     'earlier-than': 'Prima di',
                       'later-than': 'Più tardi di',
            'earlier-than-or-equal': 'Prima o uguale',
              'later-than-or-equal': 'Più tardi o uguale'
        },
        enum: {
                'equals': 'È uguale a',
            'not-equals': 'Non uguale'
        },
        boolean: {
                'equals': 'È uguale a',
            'not-equals': 'Non uguale'
        },
        filter: {
            'apply': '&#10004;',
            'remove': '&#10008;'
        },
        operator: {
            'select': '',
            'and': 'e',
             'or': 'o'
        }
    };
}
