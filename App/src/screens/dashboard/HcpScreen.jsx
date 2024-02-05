import React, { useEffect, useState } from "react";
import { Button, Card, Col, Container, Row } from "react-bootstrap";
import { getServiceProviders } from "../../services/serviceProvidersService";
import TableComponent from "../../components/TableComponent";

const HcpScreen = () => {
  const [serviceProviders, setServiceProviders] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getServiceProviders()
      .then((res) => {
        if (res.success) {
          setServiceProviders(res.data);

          setLoading(false);
        }
      })
      .catch((error) => {
        console.log(error);
        setLoading(true);
      });
  }, []);

  return (
    <>
      <TableComponent
        header="Manage Health Care Providers"
        columns={["#", "Name"]}
        Data={serviceProviders}
      />
    </>
  );
};

export default HcpScreen;
