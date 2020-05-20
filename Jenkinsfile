pipeline {
    agent {
        dockerfile {
            filename 'Dockerfile'
            additionalBuildArgs '-t myangular'
        }
    }
    stages {
        stage('Build') {
            steps {
                echo "Building..."
            }
        }
    }    
}