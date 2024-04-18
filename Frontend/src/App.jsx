import React, { useState, useEffect } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import NavBar from "./components/NavBar"
import { Table } from 'react-bootstrap'
import ReactDOM from 'react-dom'
import { Routes, Route } from 'react-router-dom'
import Guilds from './pages/Guilds'
import Home from './pages/Home'
import { RoutesNames } from './constants'
import MemberList from './components/MemberList'
import SpecificGuild from './pages/SpecificGuild'


function App() {
    return (
      <>
      <h1>Antonio Kelava's Guildbuff</h1>
        <NavBar/>
        <Routes>
        <>
          <Route path={RoutesNames.HOME} element={<Home />} />
          <Route path={RoutesNames.GUILDS} element={<Guilds />} />
          <Route path={RoutesNames.MEMBERS} element={<SpecificGuild />} />
        </>
        </Routes>
      </>
    )
  }
export default App
