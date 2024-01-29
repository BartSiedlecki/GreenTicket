import { Validator } from "fluentvalidation-ts";
import i18next from "i18next";
import { CreateAddressDto } from "../createAddressDto";

export class CreateAddressDtoValidator extends Validator<CreateAddressDto> {
    constructor() {
        super();

        const streetMaxLength = 50;
        const streetNoMaxLength = 10;
        const postalCodeMaxLength = 10;
        const cityMaxLength = 10;

        this.ruleFor('street')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("Street")))
            .maxLength(streetMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("Street"))
                .replace("#length#", streetMaxLength.toString()));

        this.ruleFor('streetNo')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("StreetNo")))
            .maxLength(streetNoMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("StreetNo"))
                .replace("#length#", streetNoMaxLength.toString()))

        this.ruleFor('postalCode')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("PostalCode")))
            .maxLength(postalCodeMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("PostalCode"))
                .replace("#length#", postalCodeMaxLength.toString()))

        this.ruleFor('city')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("City")))
            .maxLength(cityMaxLength)
            .withMessage(i18next.t("FieldMaxLength")
                .replace("#fieldName#", i18next.t("City"))
                .replace("#length#", cityMaxLength.toString()))

        this.ruleFor('countryId')
            .notEmpty()
            .withMessage(i18next.t("FieldRequired").replace("#fieldName#", i18next.t("Country")));
    }
}