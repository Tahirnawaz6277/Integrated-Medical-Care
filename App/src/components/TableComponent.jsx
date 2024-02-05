import React from "react";
import { Button, Card, Table } from "react-bootstrap";

const TableComponent = (props) => {
  const { header, columns, Data } = props;

  return (
    <>
      <Card>
        <Card.Header>{header}</Card.Header>

        <Card.Body>
          <Table responsive="sm">
            <thead>
              {columns.map((column, index) => (
                <tr key={index}>
                  <th className="float-left">{column}</th>
                </tr>
              ))}
            </thead>

            <tbody>
              {Data.map((data, index) => (
                <tr key={index}>
                  <td>{data[index]}</td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Card.Body>
      </Card>
    </>
  );
};

export default TableComponent;
