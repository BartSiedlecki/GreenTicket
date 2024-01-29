import { observer } from 'mobx-react-lite';
import React, { ChangeEvent, useEffect } from 'react';
import { Button, Col, Form, Row } from 'react-bootstrap';
import { useTranslation } from 'react-i18next';
import { useParams } from 'react-router-dom';
import customHistory from '../..';
import agent from '../../app/API/agent';
import { useStore } from '../../app/store/store';
import { prepareRoutingParamText } from '../Shared/helpers';

export default observer(function FilterForm() {
    const { t } = useTranslation();
    const { categoryPageStore: {
        categories, setCategories,
        selectedCategory, setSelectedCategory, 
        selectedSubcategory, setSelectedSubcategory,
        cities, setCities,
        selectedCity, setSelectedCity,
        loadEvents    } } = useStore()

    const { categoryId, subCategoryId, cityId } = useParams<{ categoryId: string, subCategoryId: string, cityId: string }>();

    useEffect(() => {
        agent.Categories.getNavigation()
            .then(response => setCategories(response))
            .then(() => {
                setSelectedCategory(Number(categoryId));
                setSelectedSubcategory(Number(subCategoryId));
            });

        agent.Addresses.getNavigation()
            .then(response => setCities(response))
            .then(() => {
                setSelectedCity(Number(cityId));
            });

    }, []);

    useEffect(() => {
        setSelectedCategory(Number(categoryId));
    }, [categoryId])

    useEffect(() => {
        setSelectedSubcategory(Number(subCategoryId));
    }, [subCategoryId])

    useEffect(() => {
        setSelectedCity(Number(cityId));
    }, [cityId])

    const handleCategoryChange = (event: ChangeEvent<HTMLSelectElement>) => {
        const newCategory = categories.find(x => x.id === Number(event.target.value));
        customHistory.push(`/event/category/${prepareRoutingParamText(newCategory?.title)}/${prepareRoutingParamText(selectedSubcategory?.title)}/city/${prepareRoutingParamText(selectedCity?.name)}/${newCategory?.id || "0"}/0/${selectedCity?.id || "0"}`);
    }

    const handleSubCategoryChange = (event: ChangeEvent<HTMLSelectElement>) => {
        const newSubCategory = selectedCategory?.subCategories.find(x => x.id === Number(event.target.value));

        customHistory.push(`/event/category/${prepareRoutingParamText(selectedCategory?.title)}/${prepareRoutingParamText(newSubCategory?.title)}/city/${prepareRoutingParamText(selectedCity?.name)}/${selectedCategory?.id || "0"}/${newSubCategory?.id || "0"}/${selectedCity?.id || "0"}`);

    }

    const handleCityChange = (event: ChangeEvent<HTMLSelectElement>) => {
        const newCity = cities.find(x => x.id === Number(event.target.value));

        customHistory.push(`/event/category/${prepareRoutingParamText(selectedCategory?.title)}/${prepareRoutingParamText(selectedSubcategory?.title)}/city/${prepareRoutingParamText(newCity?.name)}/${selectedCategory?.id || "0"}/${selectedSubcategory?.id || "0"}/${newCity?.id || "0"}`);

    }

    const handleClearFormClick = () => {
        customHistory.push(`/event/category/all/all/city/all/0/0/0`);

        setSelectedCategory(0);
        setSelectedSubcategory(0);
        setSelectedCity(0);
    }

    return (
        <Row className="border rounded shadow my-4">
            <Col xs={12} md={4} className="p-3">
                <Form.Group className="mb-3">
                    <Form.Label htmlFor="category" className="mb-1" >{t("Category")}</Form.Label>
                    <Form.Select
                        id="category"
                        name="category"
                        size="lg"
                        onChange={(e) => handleCategoryChange(e)}
                        value={selectedCategory?.id || 0}
                    >
                        <option key={0} value={0} >{t("All")}</option>
                        {categories.map(category => (
                            <option key={category.id} value={category.id} >{t(category.title)}</option>
                        ))}
                    </Form.Select>
                </Form.Group>
            </Col>
            <Col xs={12} md={4} className="p-3">
                <Form.Group className="mb-3">
                    <Form.Label htmlFor="subcategory" className="mb-1" >{t("Subcategory")}</Form.Label>
                    <Form.Select
                        id="subcategory"
                        name="subcategory"
                        size="lg"
                        onChange={(e) => handleSubCategoryChange(e)}
                        value={selectedSubcategory?.id || 0}
                    >
                        <option key={0} value={0} >{t("All")}</option>
                        {selectedCategory?.subCategories.map(subcategory => (
                            <option key={subcategory.id} value={subcategory.id} >{t(subcategory.title)}</option>
                        ))}
                    </Form.Select>
                </Form.Group>
            </Col>
            <Col xs={12} md={4} className="p-3">
                <Form.Group className="mb-3">
                    <Form.Label htmlFor="city" className="mb-1" >{t("City")}</Form.Label>
                    <Form.Select
                        id="city"
                        name="city"
                        size="lg"
                        onChange={(e) => handleCityChange(e)}
                        value={selectedCity?.id || 0}
                    >
                        <option key={0} value={0} >{t("All")}</option>
                        {cities.map((city, index) => (
                            <option key={index} value={city.id} >{city.name}</option>
                        ))}
                    </Form.Select>
                </Form.Group>
            </Col>
            <Col xs={12} className="text-center mb-3">
                <Button variant="secondary" onClick={() => handleClearFormClick()}>{t("Clear")}</Button>{' '}
            </Col>
        </Row>
    )
})