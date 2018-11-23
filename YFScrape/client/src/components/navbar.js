import React from 'react'
import PropTypes from 'prop-types'

const Navbar = ({userName}) => {
  return (
    <nav className="nav-wrapper red darken-3">
      <div className="container">
        <ul className="left">
          <li><a href="/">Home</a></li>
          <li><a href="/login">Login</a></li>
          <li><a href="/portfolio">Portfolio</a></li>
          <li><a href="/about">About</a></li>
        </ul>
        <a className="brand-logo center" href="/">YFScrape</a>
        <span className="right">Logged in as: {userName}</span>
      </div>
    </nav>
  )
}

Navbar.propTypes = {
  userName: PropTypes.string
}

export default Navbar