import { Validator } from "fluentvalidation-ts";
import i18next from "i18next";
import { PaymentCardDto } from "../paymentCardDto";

export class PaymentCardValidator extends Validator<PaymentCardDto> {
    constructor() {
        super();

        this.ruleFor('cardNo')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("CardNo")))
            .matches(/^[0-9]{16}$/)
            .withMessage(i18next.t("InvalidFieldValue"));

        this.ruleFor('cardHolderName')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("FullName")))
            .matches(/^[a-zA-Z ]+$/)
            .withMessage(i18next.t("InvalidFieldValue"));

        this.ruleFor('expireMonth')
            .notNull()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("ExpireMonth")))
            .matches(/^[0-9]{2}$/)
            .withMessage(i18next.t("InvalidFieldValue"));

        this.ruleFor('expireYear')
            .notNull()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("ExpireYear")))
            .matches(/^[0-9]{4}$/)
            .withMessage(i18next.t("InvalidFieldValue"));

        this.ruleFor('CVV')
            .notNull()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("ExpireYear")))
            .length(3,3)
            .withMessage(i18next.t("InvalidFieldValue"));

    }
}