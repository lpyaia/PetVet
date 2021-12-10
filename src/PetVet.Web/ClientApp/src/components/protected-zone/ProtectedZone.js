import React, {Component} from "react";
import authService from '../api-authorization/AuthorizeService';

export class ProtectedZone extends Component {
    constructor(props) {
        super(props);

        this.state = {
            isAuthenticated: false
        }
    }

    componentDidMount() {
        this.authenticationUpdated();
    }

    componentWillUnmount() {
    }

    async authenticationUpdated() {
        const isAuthenticated = await authService.isAuthenticated();

        console.log('passou')

        if (isAuthenticated) {
            const user = await authService.getUser();
            this.setState({user: user});
        }

        this.setState({isAuthenticated: isAuthenticated});
    }

    render() {
        const {isAuthenticated, user} = this.state;
        const component = this.props.children;
        const allowedRole = this.props.role;

        if (isAuthenticated && allowedRole === user.role) {
            return component;
        } else {
            return (
                <div>
                </div>
            );
        }
    }
}
