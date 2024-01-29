import { Container } from 'react-bootstrap';
import OrderListoryList from './OrderHistoryList';
import OrderHistoryTitle from './OrderHistoryPageTitle';

export default function OrderHistoryPage() {

    

    return (
        <>
            <Container className="p-5" fluid >
                <OrderHistoryTitle />
                <OrderListoryList />
            </Container>

        </>
    )
}