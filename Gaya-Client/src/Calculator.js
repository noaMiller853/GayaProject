import { useEffect, useState } from "react";
import { Container, Row, Col, Form, Button, Table } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import { CalculateService } from "./CalculateService";

const Calculator = () => {
  const [field1, setField1] = useState("");
  const [field2, setField2] = useState("");
  const [operation, setOperation] = useState("");
  const [result, setResult] = useState("");
  const [operations, setOperations] = useState([]);
  const [listArgument, setListArgument] = useState([]);

  useEffect(() => {
    CalculateService.getListOperators().then((data) => {
      setOperations(data);
    });
  }, []);

  const calculate = async () => {
    if (!field1 || !field2 || !operation) {
      setResult("אנא מלא את כל השדות");
      return;
    }

    try {
      const data = await CalculateService.addArguments(
        field1,
        field2,
        operation
      );
      setResult(data);
    } catch (error) {
      setResult("error calculate");
      console.error(error);
    }

    const selectedOp = operations.find((op) => op.operation === operation);
    if (selectedOp) {
      try {
        const result = await CalculateService.getArgumentByIdOperator(
          selectedOp.id
        );
        setListArgument(result);
      } catch (error) {
        console.error("Error fetching arguments:", error);
      }
    }
  };

  return (
    <Container className="my-5">
      <Row className="justify-content-center">
        <Col md={6}>
          <Form>
            <Form.Group className="mb-2">
              <Form.Label>Input</Form.Label>
              <Form.Control
                type="text"
                placeholder="Field 1"
                value={field1}
                onChange={(e) => setField1(e.target.value)}
                size="sm"
              />
            </Form.Group>
            <Form.Group className="mb-2">
              <Form.Label>Drop-down list</Form.Label>
              <Form.Select
                value={operation}
                onChange={(e) => setOperation(e.target.value)}
                size="sm"
              >
                <option value="">Operation</option>
                {operations.map((op) => (
                  <option key={op.id} value={op.operation}>
                    {op.operation}
                  </option>
                ))}
              </Form.Select>
            </Form.Group>

            <Form.Group className="mb-2">
              <Form.Label>Input</Form.Label>
              <Form.Control
                type="text"
                placeholder="Field 2"
                value={field2}
                onChange={(e) => setField2(e.target.value)}
                size="sm"
              />
            </Form.Group>

            <Button variant="secondary" onClick={calculate} size="sm">
              CALCULATE
            </Button>

            <div className="mt-4">
              <div className="font-weight-bold">RESULT:</div>
              <div className="border border-dark p-2 mt-2">{result}</div>
            </div>
          </Form>
        </Col>
      </Row>
      <Row className="justify-content-center mt-4">
        <Col md={8}>
          <h4>Arguments List</h4>
          {listArgument.length > 0 ? (
            <Table striped bordered hover>
              <thead>
                <tr>
                  <th>field1</th>
                  <th>Operator</th>
                  <th>field2</th>
                  <th>Result</th>
                </tr>
              </thead>
              <tbody>
                {listArgument.map((arg, index) => (
                  <tr key={index}>
                    <td>{arg.fieldOne}</td>
                    <td>{operation}</td>
                    <td>{arg.fieldTwo}</td>
                    <td>{arg.result}</td>
                  </tr>
                ))}
              </tbody>
            </Table>
          ) : (
            <p>No arguments found</p>
          )}
        </Col>
      </Row>
    </Container>
  );
};

export default Calculator;
