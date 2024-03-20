import React, { useEffect, useState } from "react";
import { Card, Table } from "react-bootstrap";
import { GetServiceProviders } from "../../../services/serviceProvidersService";

export const HcpRecordScreen = () => {
  const [HCP, setHCP] = useState([]);
  const [loading, setLoading] = useState(true);

  const fetchServiceProviders = () => {
    GetServiceProviders()
      .then((res) => {
        if (res.success) {
          console.log(res);
          setHCP(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  useEffect(() => {
    fetchServiceProviders();
  }, []);

  return (
    <Card>
      <Card.Header>Manage Service Provider Records</Card.Header>

      <Card.Body>
        <Table responsive="sm">
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>Phone Number</th>
              <th>Provided Services</th>
              <th>Service Rating</th>
              <th>Service Feedbacks</th>
              <th>Ordered Services</th>
            </tr>
          </thead>

          <tbody>
            {HCP.map((hcp, index) => (
              <tr key={index}>
                <td>{index + 1}</td>
                <td>{hcp.providerName}</td>
                <td>{hcp.user.phoneNumber}</td>
                <td>{hcp.givenServices}</td>
                <td>{hcp.serviceRating}</td>
                <td>{hcp.serviceFeedbacks}</td>
                <td>{hcp.orderedServices}</td>
              </tr>
            ))}
          </tbody>
        </Table>
      </Card.Body>
    </Card>
  );
};
