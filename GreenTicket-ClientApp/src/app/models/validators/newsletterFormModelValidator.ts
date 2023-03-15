import { Validator } from "fluentvalidation-ts";
import { NewsletterFormModel } from "../newsletterFormModel";

class NewsletterFormModelValidator extends Validator<NewsletterFormModel>
{
    constructor() {
        super();

        this.ruleFor('email')
            .notNull()
            .maxLength(50)
            .emailAddress();

        this.ruleFor('agreement')
            .notNull()
            .notEqual(false);
    }
}

export default NewsletterFormModelValidator;