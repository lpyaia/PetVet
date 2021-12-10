import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/layout/Layout';
import { Home } from './components/home/Home';
import { FetchData } from './components/fetch-data/FetchData';
import { Counter } from './components/counter/Counter';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import { MyPets } from './components/my-pets/MyPets';

import './custom.css';
import 'bootstrap/dist/css/bootstrap.min.css';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <AuthorizeRoute path='/fetch-data' component={FetchData} />
        <AuthorizeRoute path='/my-pets' component={MyPets} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
    );
  }
}
