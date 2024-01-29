import { useEffect, useState } from "react";
import { Container } from "react-bootstrap";
import { useTranslation } from "react-i18next";
import { useParams } from "react-router-dom";
import agent from "../../app/API/agent";
import { PaymentOrderDto } from "../../app/models/paymentOrderDto";
import { useStore } from "../../app/store/store";
import PaymentForm from "./PaymentForm";
import PaymentPageTitle from "./PaymentPageTitle";

export default function PaymentPage() {
	const { userStore } = useStore();
	const { user } = userStore;
	const { orderId } = useParams<{ orderId: string }>();
	const { t } = useTranslation()

	const [order, setOrder] = useState<PaymentOrderDto | undefined>(undefined);

	useEffect(() => {
		if (user && orderId) {
			agent.Orders.getForPayment(user.id, orderId).then(response => {
				setOrder(response);
			})
		};
	}, [orderId, user])


    return <>
        <Container className="p-5" fluid >
			{order && !order.alreadyPaid ?
				<>
					<PaymentPageTitle />
					<PaymentForm order={order} />
				</>
				:
				undefined
			}	
			{order && order.alreadyPaid ?
				<>
					<PaymentPageTitle />
				</>
				:
				undefined
			}	
        </Container>
    </>
}
