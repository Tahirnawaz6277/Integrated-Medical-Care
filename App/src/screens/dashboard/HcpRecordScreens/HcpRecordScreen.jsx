import React, { useEffect, useState } from "react";
import { Button, Card, Table } from "react-bootstrap";
import { GetServiceProviders } from "../../../services/serviceProvidersService";
import { deleteUser } from "../../../services/accountService";

export const HcpRecordScreen = () => {
  const [HCP, setHCP] = useState([]);
  const [loading, setLoading] = useState(true);

  const fetchServiceProviders = () => {
    GetServiceProviders()
      .then((res) => {
        if (res.success) {
          let serviceProviders = res.data.filter((hcp) => {
            return hcp.role === "ServiceProvider";
          });

          setHCP(serviceProviders);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const handleDelete = (id) => {
    deleteUser(id)
      .then((res) => {
        if (res.success) {
          fetchServiceProviders();
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };
  useEffect(() => {
    fetchServiceProviders();
  }, []);

  return (
    <Card>
      <Card.Header
        style={{
          background: "black  ",
          padding: "20px ",
          color: "white",
        }}
      >
        Manage Service Provider Records
      </Card.Header>

      <Card.Body>
        <Table responsive="sm">
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>Gender</th>
              <th>Phone Number</th>
              <th> Speciality </th>
              <th> Provided Services </th>

              <th>Rating</th>
              <th></th>
            </tr>
          </thead>

          <tbody>
            {HCP.map((hcp, index) => (
              <React.Fragment key={index}>
                <tr>
                  <td>{index + 1}</td>
                  <td>{hcp.firstName}</td>
                  <td>{hcp.gender}</td>
                  <td>{hcp.phoneNumber}</td>
                  <td>
                    {hcp.serviceProviderType
                      ? hcp.serviceProviderType.providerName
                      : "N/A"}
                  </td>
                  <td>
                    {hcp.services.length > 0
                      ? hcp.services.map((service, serviceIndex) => (
                          <span key={serviceIndex}>
                            {service.serviceName}
                            {serviceIndex !== hcp.services.length - 1 && ", "}
                          </span>
                        ))
                      : "N/A"}
                  </td>

                  <td>
                    {hcp.services.length > 0 ? (
                      hcp.services.some(
                        (service) =>
                          service.user_Feedbacks &&
                          service.user_Feedbacks.length > 0
                      ) ? (
                        <b>
                          {(
                            hcp.services.reduce((total, service) => {
                              if (
                                service.user_Feedbacks &&
                                service.user_Feedbacks.length > 0
                              ) {
                                return (
                                  total +
                                  service.user_Feedbacks.reduce(
                                    (acc, feedback) => acc + feedback.rating,
                                    0
                                  ) /
                                    service.user_Feedbacks.length
                                );
                              } else {
                                return total;
                              }
                            }, 0) /
                            hcp.services.filter(
                              (service) =>
                                service.user_Feedbacks &&
                                service.user_Feedbacks.length > 0
                            ).length
                          ).toFixed(2)}
                        </b>
                      ) : (
                        <p>N/A</p>
                      )
                    ) : (
                      <p>N/A</p>
                    )}
                  </td>

                  <td>
                    <Button
                      className="btn-custom btn btn-danger"
                      onClick={() => {
                        handleDelete(hcp.id);
                      }}
                    >
                      Delete
                    </Button>
                  </td>
                </tr>
              </React.Fragment>
            ))}
          </tbody>
        </Table>
      </Card.Body>
    </Card>
  );
};
