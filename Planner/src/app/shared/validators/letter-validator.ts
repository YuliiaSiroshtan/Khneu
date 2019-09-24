import { AbstractControl } from "@angular/forms";

export function ValidateLetter(control: AbstractControl) {
    let pattern = /^[a-zа-я-A-ZА-і-ЯЄI-а-яєi]+$/;
    if (!pattern.test(control.value)) {
        return { validLetter: true }
    }
    return null;
}
