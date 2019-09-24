import { SelectItem } from 'primeng/api';

export class ApplicationConstants {
    public static readonly ROLES: SelectItem[] = [
        { label: 'Адміністратор', value: 'Admin' },
        { label: 'Голова методичного відділу', value: 'HeadOfMethodologyDepartment' },
        { label: 'Голова наукового сектора', value: 'HeadOfScientificSector' },
        { label: 'Голова навчальної частини', value: 'HeadOfStudies' },
        { label: 'Викладач', value: 'Teacher' },
        { label: 'Викладач-модератор', value: 'TeacherModerator' },
        { label: 'Користувач', value: 'User' }
    ];


    public static readonly ACADEMIC_TITLE: SelectItem[] = [
        { label: 'Кандидат наук', value: '1' },
        { label: 'Доктор наук', value: '2' },
    ];

    public static readonly DEGREE: SelectItem[] = [
        { label: 'Доцент', value: '1' },
        { label: 'Старший науковий співробітник', value: '2' },
        { label: 'Професор', value: '3' },
    ];

    public static readonly POSITION: SelectItem[] = [
        { label: 'Завідуючий кафедрою', value: '1' },
        { label: 'Доцент кафедрою', value: '2' },
        { label: 'Старший викладач кафедри', value: '3' },
        { label: 'Викладач кафедри', value: '4' },
        { label: 'Асистент', value: '5' }
    ];
    public static readonly RESEARCHDONETYPE: SelectItem[] = [
        { label: 'Держбюджет', value: '1' },
        { label: 'Госпдоговірна тема', value: '2' },
        { label: 'За індивідуальним планом викладача', value: '3' },
        { label: 'Iншi', value: '4' }
    ];

    public static readonly STORINGTYPE: SelectItem[] = [
        { label: 'Друковане видання', value: '1' },
        { label: 'Електронне видання', value: '2' }
    ];

    public static readonly PUBLICATION: SelectItem[] = [
        { label: 'Тези доповіді', value: '1' },
        { label: 'Стаття', value: '2' },
        { label: 'Звіт про НДР', value: '3' },
        { label: 'Патент', value: '4' },
        { label: 'Навчальний посібник', value: '5' },
        { label: 'Лабораторний практикум', value: '6' },
        { label: 'Монографія', value: '7' },
        { label: 'Робоча програма', value: '8' },
        { label: 'Навчально-практичний поcібник', value: '9' },
        { label: 'Коллективная монография', value: '10' },
        { label: 'Електронний навчальний посібник', value: '11' },
    ];


}

