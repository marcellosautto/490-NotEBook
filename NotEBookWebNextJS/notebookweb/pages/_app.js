import '../styles/globals.css'
import 'bootstrap/dist/css/bootstrap.css'
import React from 'react'
import MainLayout from '../components/layouts/MainLayout'

function MyApp({ Component, pageProps }) {
  return (
    <MainLayout>
      <Component {...pageProps} />
    </MainLayout>
  );
}

export default MyApp
