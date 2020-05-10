import { AbstractControl } from "@angular/forms";

export function ValidateURL(control: AbstractControl) {
    let pattern = /^(http[s]?:\/\/){0,1}(www\.){0,1}[a-zA-Z0-9\.\-]+\.[a-zA-Z]{2,5}[\.]{0,1}/;
    if (!pattern.test(control.value) && (control.value != '' && control.value != null)) {
        return { validURL: true }
    }
    return null;
}
