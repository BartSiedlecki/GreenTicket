import { Validator } from "fluentvalidation-ts";
import i18next from "i18next";
import { BlikCodeDto } from "../blikCodeDto";

export class BlikCodeValidator extends Validator<BlikCodeDto> {
    constructor() {
        super();

        const blikCodeMinLength = 5;
        const blikCodeMaxLength = 6;

        this.ruleFor('code')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("BlikCode")))
            .minLength(blikCodeMinLength)
            .withMessage(i18next.t("FieldMinLength")
                .replace("#fieldName#", i18next.t("BlikCode"))
                .replace("#length#", blikCodeMinLength.toString()))
            .maxLength(blikCodeMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("BlikCode"))
                .replace("#length#", blikCodeMaxLength.toString()))
    }
}