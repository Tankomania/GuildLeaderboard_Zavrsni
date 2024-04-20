import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { useNavigate } from 'react-router-dom';
import { RoutesNames, App } from '../constants';

const NavBar = () => {

  const navigate = useNavigate();
  
  return (
    <Navbar expand="lg" className="bg-body-tertiary">
          <Nav className="me-auto" style={{ display: 'flex', flexDirection: 'row' }}>
            
              <NavDropdown.Item  onClick={()=>navigate(RoutesNames.HOME)}>Home</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item  onClick={()=>navigate(RoutesNames.GUILDS)}>Guilds</NavDropdown.Item>
              <NavDropdown.Divider />
          </Nav>    
    </Navbar>
  );
}

export default NavBar;
