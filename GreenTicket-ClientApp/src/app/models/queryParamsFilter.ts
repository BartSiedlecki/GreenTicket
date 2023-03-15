export class QueryParamsFilter {
    categoryId: number | undefined;
    subCategoryId: number | undefined;
    cityId: number | undefined;

    constructor(categoryId: number | undefined = undefined, subCategoryId: number | undefined = undefined, cityId: number | undefined = undefined) {
        this.categoryId = categoryId === 0 ? undefined : categoryId;
        this.subCategoryId = subCategoryId === 0 ? undefined : subCategoryId;
        this.cityId = cityId === 0 ? undefined : cityId;
    }
}