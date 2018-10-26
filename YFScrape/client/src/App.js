import React, { Component } from 'react';
import './App.css';
import Navbar from "./components/navbar";

class App extends Component {
  componentWillMount() {
    fetch("/api/newportfolio")
      .then(res => res.json())
      .then(res => console.log(res))
      .then(res => this.setState({data: res}));
  }

  render() {
    return (
      <div>
        <Navbar />
      </div>
    );
  }
}

export default App;
