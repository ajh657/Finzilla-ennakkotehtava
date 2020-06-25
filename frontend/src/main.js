import React, { Component } from "react";
import {
    Route,
    NavLink,
    HashRouter
  } from "react-router-dom";
import Customers from "./Customer"
import Table from "./table"
import "./index.css"
import { JsonToTable } from "react-json-to-table";
const request = require('request');

class Main extends Component {
  constructor(props){
    super(props);
    this.state = {
        data: {}
    };
  }

  componentDidMount() {
    
    fetch("https://localhost:44390/Customer")
      .then(res => res.json())
      .then(json => this.setState({ data: json }));
  }
  render() {
    return (
        <HashRouter>
          
        <div>
          <h1>Simple SPA</h1>
          <ul className="header">
            <li><a href="/Customers">Stuff</a></li>
          </ul>
          <div className="content">
          <JsonToTable json={this.state.data} />
          </div>
        </div>
        </HashRouter>
    );
  }
}
 
export default Main;