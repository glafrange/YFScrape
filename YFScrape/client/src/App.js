import React, { Component } from 'react'
import './App.css'
import Navbar from './components/navbar'

class App extends Component {
  componentDidMount() {
    fetch('/api/newportfolio')
      .then(res => res.json())
      .then(res => this.setState({stocks: res}))
      .then(() => console.log(this.state.stocks))
      .catch(err => console.log(err))
  }

  render() {
    return (
      <div>
        <Navbar userName='admin'/>
      </div>
    )
  }
}

export default App
