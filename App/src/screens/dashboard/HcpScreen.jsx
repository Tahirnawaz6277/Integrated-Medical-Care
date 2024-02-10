// // import React, { useEffect, useState } from "react";
// // import { Button, Card, Col, Container, Row } from "react-bootstrap";
// // import { getServiceProviders } from "../../services/serviceProvidersService";
// // import TableComponent from "../../components/TableComponent";

// // const HcpScreen = () => {
// //   const [serviceProviders, setServiceProviders] = useState([]);
// //   const [loading, setLoading] = useState(true);

// //   useEffect(() => {
// //     getServiceProviders()
// //       .then((res) => {
// //         if (res.success) {
// //           setServiceProviders(res.data);

// //           setLoading(false);
// //         }
// //       })
// //       .catch((error) => {
// //         console.log(error);
// //         setLoading(true);
// //       });
// //   }, []);

// //   return (
// //     <>
// //       <TableComponent
// //         header="Manage Health Care Providers"
// //         columns={["#", "Name"]}
// //         Data={serviceProviders}
// //       />
// //     </>
// //   );
// // };

// // export default HcpScreen;

// import React, { useEffect, useState } from "react";
// import { Button, Card, Spinner, Table } from "react-bootstrap";
// import {
//   getServiceProviders,
//   DeleteServiceProviders,
//   AddServiceProviders,
//   UpdateServiceProviders,
// } from "../../services/serviceProvidersService";

// const HcpScreen = () => {
//   const [HCP, setHCP] = useState([]);
//   const [loading, setLoading] = useState(true);

//   const updatedHCP = () => {
//     getServiceProviders()
//       .then((res) => {
//         if (res.success) {
//           setHCP(res.data);
//           setLoading(false);
//         }
//       })
//       .catch((err) => {
//         setLoading(true);
//         console.log(err);
//       });
//   };
//   const handleDelete = (id) => {
//     console.log(id);
//     DeleteServiceProviders(id)
//       .then((res) => {
//         if (res.success) {
//           updatedHCP();
//         }
//       })
//       .catch((err) => {
//         console.log(err.message);
//       });
//   };

//   useEffect(() => {
//     updatedHCP();
//   }, []);

//   return (
//     <>
//       <Card>
//         <Card.Header>
//           Manage Health Care Provider
//           <Button className="float-end">Add NEW HCP</Button>
//         </Card.Header>

//         <Card.Body>
//           {loading && <Spinner size="sm" />}
//           <Table responsive="sm">
//             <thead>
//               <tr>
//                 <th>#</th>
//                 <th>Name</th>
//                 <th>Date Created</th>
//                 <th>Action</th>
//               </tr>
//             </thead>

//             <tbody>
//               {HCP.map((user, index) => (
//                 <tr key={index}>
//                   <td>{index}</td>
//                   <td>{user.firstName}</td>
//                   <td>{user.createdAt}</td>
//                   <td style={{ display: "flex", gap: "8px" }}>
//                     <Button variant="primary">Edit</Button>

//                     <Button
//                       className="btn btn-danger"
//                       onClick={() => {
//                         handleDelete(user.id);
//                       }}
//                     >
//                       Delete
//                     </Button>
//                   </td>
//                 </tr>
//               ))}
//             </tbody>
//           </Table>
//         </Card.Body>
//       </Card>
//     </>
//   );
// };

// export default HcpScreen;

import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import {
  GetServiceProviders,
  DeleteServiceProviders,
  AddServiceProviders,
  UpdateServiceProviders,
} from "../../services/serviceProvidersService";

const HcpScreen = () => {
  const [HCP, setHCP] = useState([]);
  const [loading, setLoading] = useState(true);

  const updatedHCP = () => {
    GetServiceProviders()
      .then((res) => {
        if (res.success) {
          setHCP(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
        console.log(err);
      });
  };

  const handleDelete = (id) => {
    DeleteServiceProviders(id)
      .then((res) => {
        if (res.success) {
          updatedHCP();
        }
      })
      .catch((err) => {
        console.log(err.message);
        // Display error message to the user if the deletion fails
      });
  };
  useEffect(() => {
    updatedHCP();
  }, []);

  return (
    <>
      <Card>
        <Card.Header>
          Manage Health Care Providers
          <Button className="float-end">Add NEW HCP</Button>
        </Card.Header>

        <Card.Body>
          {loading && <Spinner animation="border" />}
          <Table responsive="sm">
            <thead>
              <tr>
                <th>#</th>
                <th>Name</th>
                <th>Date Created</th>
                <th>Action</th>
              </tr>
            </thead>

            <tbody>
              {HCP.map((user, index) => (
                <tr key={index}>
                  <td>{index + 1}</td>
                  <td>{user.name}</td>
                  <td>{user.dateCreated}</td>
                  <td style={{ display: "flex", gap: "8px" }}>
                    <Button variant="primary">Edit</Button>
                    <Button
                      variant="danger"
                      onClick={() => {
                        handleDelete(user.id);
                      }}
                    >
                      Delete
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Card.Body>
      </Card>
    </>
  );
};

export default HcpScreen;
