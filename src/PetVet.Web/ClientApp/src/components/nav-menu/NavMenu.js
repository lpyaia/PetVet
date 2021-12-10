import React,
{ Component } from 'react';
import
{



    Collapse,
    Container,
    Navbar,
    NavbarBrand,
    NavbarToggler,
    NavItem,
    NavLink,
    UncontrolledDropdown,
    DropdownToggle,
    DropdownItem,
    DropdownMenu



} from 'reactstrap';
import
{ Link } from 'react-router-dom';
import
{ LoginMenu } from '../api-authorization/LoginMenu';
import authService from '../api-authorization/AuthorizeService';
import
{ ProtectedZone } from '../protected-zone/ProtectedZone';
import './NavMenu.css';

export class NavMenu extends Component
{



    static displayName = NavMenu.name;

    constructor( props )
    {



        super( props );

        this.toggleNavbar = this.toggleNavbar.bind( this );
        this.state = {



            collapsed: true



        };



    }

    componentDidMount()
    {}

    componentWillUnmount()
    {}

    toggleNavbar()
    {



        this.setState( {



            collapsed: !this.state.collapsed



        } );



    }

    async authenticationChangedx()
    {



        const user = await authService.getUser();
        this.setState( { user: user } );



    }

    render()
    {



        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                    <Container>
                        <NavbarBrand tag={Link}
                            to="/">PetVet.Web</NavbarBrand>
                        <NavbarToggler onClick={
                                this.toggleNavbar
                            }
                            className="mr-2"/>
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse"
                            isOpen={
                                !this.state.collapsed
                            }
                            navbar>
                            <ul className="navbar-nav flex-grow">
                                <NavItem>
                                    <NavLink tag={Link}
                                        className="text-dark"
                                        to="/">Home</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link}
                                        className="text-dark"
                                        to="/counter">Counter</NavLink>
                                </NavItem>
                                <ProtectedZone role="Customer">
                                    <NavItem>
                                        <NavLink tag={Link}
                                            className="text-dark"
                                            to="/fetch-data">Fetch data</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link}
                                                className="text-dark"
                                                to="/my-pets">My Pets</NavLink>
                                        {/* <UncontrolledDropdown inNavbar nav>
                                            <DropdownToggle tag={Link}
                                                to="/my-pets"
                                                className="text-dark"
                                                caret
                                                nav>
                                                My Pets
                                            </DropdownToggle>
                                            <DropdownMenu right>
                                                <DropdownItem tag={Link}
                                                    to="/counter">
                                                    Register
                                                </DropdownItem>
                                                <DropdownItem>
                                                    Option 2
                                                </DropdownItem>
                                                <DropdownItem divider/>
                                                <DropdownItem>
                                                    Reset
                                                </DropdownItem>
                                            </DropdownMenu>
                                        </UncontrolledDropdown> */}
                                    </NavItem>
                                </ProtectedZone>
                                <LoginMenu></LoginMenu>
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );



    }

}
