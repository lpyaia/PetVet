import React, {Component} from "react";
import { Row, Col } from "reactstrap";


export class MyPets extends Component {
    constructor(props){
        super(props);
    }

    componentDidMount() {

    }

    componentDidUpdate() {

    }

    componentWillUnmount() {

    }

    render() {
        return (
            <div>
                <Row>
                    <Col>
                        <h1>SECTION 1</h1>
                    </Col>
                    <Col>
                        <h1>SECTION 2</h1>
                    </Col>
                </Row>
            </div>
        );
    }
}